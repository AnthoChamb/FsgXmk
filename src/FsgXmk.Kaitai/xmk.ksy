meta:
  id: xmk
  file-extension: xmk
  endian: be
seq:
  - id: header
    type: xmk_header
  - id: tempos
    type: xmk_tempo
    repeat: expr
    repeat-expr: header.num_tempos
  - id: time_signatures
    type: xmk_time_signature
    repeat: expr
    repeat-expr: header.num_time_signatures
  - id: events
    type: xmk_event
    repeat: expr
    repeat-expr: header.num_events
  - id: blobs
    type: xmk_blobs
    size: header.len_blobs
types:
  xmk_header:
    seq:
      - id: version
        type: u4
      - id: hash
        size: 4
      - id: num_events
        type: u4
      - id: len_blobs
        type: u4
      - size: 4
      - id: num_tempos
        type: u4
      - id: num_time_signatures
        type: u4
  xmk_tempo:
    seq:
      - id: ticks
        type: u4
      - id: start
        type: f4
      - id: tempo
        type: u4
  xmk_time_signature:
    seq:
      - id: ticks
        type: u4
      - id: measure
        type: u4
      - id: numerator
        type: u4
      - id: denominator
        type: u4
  xmk_event:
    seq:
      - id: group_index
        type: u4
      - id: chord
        type: u2
        enum: xmk_event_chord
      - id: type
        type: u1
        enum: xmk_event_type
      - id: note
        type: u1
        enum: xmk_event_note
      - id: start
        type: f4
      - id: end
        type: f4
      - size: 4
      - id: ofs_blob
        type: u4
    enums:
      xmk_event_chord:
        2: barre
        4: b1
        8: b2
        16: b3
        32: w1
        64: w2
        128: w3
      xmk_event_type:
        3: section
        4: hopo_detection
        56: highway
        0: casual
        8: easy
        16: medium
        24: hard
        32: expert
        64: sustain
        72: sustain_easy
        80: sustain_medium
        88: sustain_hard
        96: sustain_expert
        128: hopo
        136: hopo_easy
        144: hopo_medium
        152: hopo_hard
        160: hopo_expert
        192: hopo_sustain
        200: hopo_sustain_easy
        208: hopo_sustain_medium
        216: hopo_sustain_hard
        224: hopo_sustain_expert
      xmk_event_note:
        1: casual_open
        3: casual_hp
        5: easy_b1
        6: easy_w1
        7: easy_b2
        8: easy_w2
        9: easy_b3
        10: easy_w3
        15: easy_open
        20: easy_hp
        23: medium_b1
        24: medium_w1
        25: medium_b2
        26: medium_w2
        27: medium_b3
        28: medium_w3
        33: medium_open
        38: medium_hp
        41: hard_b1
        42: hard_w1
        43: hard_b2
        44: hard_w2
        45: hard_b3
        46: hard_w3
        51: hard_open
        56: hard_hp
        59: expert_b1
        60: expert_w1
        61: expert_b2
        62: expert_w2
        63: expert_b3
        64: expert_w3
        69: expert_open
        74: expert_hp
        78: highway
        128: section
  xmk_blobs:
    seq:
      - id: values
        type: strz
        encoding: ASCII
        repeat: eos
